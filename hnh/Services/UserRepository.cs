using hnh.Data;
using hnh.Models;
using Microsoft.AspNetCore.Identity;


namespace hnh.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbcontext _context;
        public UserRepository(MyDbcontext context)
        {
            _context = context;
        }


        public UserVM AddUser(UserVM user)
        {
            if (user == null    )
            {
                throw new ArgumentNullException(nameof(user));
            }
            // ma hoa mat khau
                //user.password = BCrypt.Net.BCrypt.HashPassword(user.password, 13);
            // tao token
            user.remembertoken = Guid.NewGuid();


            if (string.IsNullOrEmpty(user.status))
            {
                user.status = "1";
            }
            
            if (string.IsNullOrEmpty(user.role))
            {
                user.role = "0";
            }

            // them nguoi dung
            var newUser = new User
            {
                name            = user.name,
                password        = user.password,
                email           = user.email,
                role            = user.role,
                phone           = user.phone,
                remembertoken   = user.remembertoken,
                createdat       = user.createdat,
                updatedat       = user.updatedat,
                status          = user.status
            };
            _context.users.Add(newUser);
            Save();
            return new UserVM
            {
                name = newUser.name,
                email = newUser.email,
            };


        }

        public void DeleteUser(int id)
        {
            // xoa nguoi dung
            var userFromDb = _context.users.FirstOrDefault(c => c.userid == id);
            if (userFromDb == null)
            {
                throw new Exception("Không tìm thấy người dùng với id đã cung cấp");
            }
            _context.users.Remove(userFromDb);
            Save();

        }

        public UserVM GetUser(int id)
        {
            var userFromDb = _context.users.SingleOrDefault(c => c.userid == id);
            if (userFromDb == null)
            {
                throw new Exception("Không tìm thấy người dùng với id đã cung cấp");
            }
            else
            {
                var userVM = new UserVM
                {
                    userid = userFromDb.userid,
                    name = userFromDb.name,
                    email = userFromDb.email,
                    password = userFromDb.password,
                    role = userFromDb.role,
                    phone = userFromDb.phone,
                    avatar = userFromDb.avatar,
                    remembertoken = userFromDb.remembertoken,
                    createdat = (DateTime)userFromDb.createdat,
                    updatedat = (DateTime)userFromDb.updatedat,
                    status = userFromDb.status

                };
                return userVM;
            }
        }

        public IEnumerable<UserVM> GetUsers()
        {
            var usersFromDb = _context.users.ToList();
            var usersVM = usersFromDb.Select(c => new UserVM
            {
                userid = c.userid,
                name = c.name,
                email = c.email,
                password = c.password,
                role = c.role,
                phone = c.phone,
                avatar = c.avatar,
                remembertoken = c.remembertoken,
                createdat = (DateTime)c.createdat,
                updatedat = (DateTime)c.updatedat,
                status = c.status
            });
            return usersVM.ToList();
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserVM UpdateUser(UserVM user)
        {
            // truy vấn người dùng từ cơ sở dữ liệu
            var userFromDb = _context.users.FirstOrDefault(c => c.userid == user.userid);
            if (userFromDb == null)
            {
                throw new Exception("Không tìm thấy người dùng với id đã cung cấp");
            }
            if (!isAdmin(user))
            {
                // cập nhật thông tin người dùng
                userFromDb.name = user.name;
                userFromDb.email = user.email;
                userFromDb.password = user.password;
                userFromDb.role = user.role;
                userFromDb.phone = user.phone;
                userFromDb.avatar = user.avatar;
                userFromDb.remembertoken = user.remembertoken;
                userFromDb.status = user.status;
            }
            else
            {
                userFromDb.name = user.name;
                userFromDb.phone = user.phone;
                userFromDb.avatar = user.avatar;
                userFromDb.password = user.password;
            }
            Save();
            return new UserVM
            {
                userid = userFromDb.userid,
                name = userFromDb.name,
                email = userFromDb.email,
            };

        }

        public bool UserExists(int id)
        {
            return _context.users.Any(e => e.userid == id);
        }
        public bool isAdmin(UserVM user)
        {
            if(user.role == "1")
            {
                return true;
            }
            return false;
        }
    }
}
