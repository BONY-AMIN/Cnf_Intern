using CnF.Domain.Models;

using CnF.Domain.Repositories;
using CnF.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnF.Core.Services
{
    public class UserProfileService
    {
        private UnitOfWork unitOfWork;

        public UserProfileService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void Create(UserProfileViewModel userProfileVM)
        {
            var UserProfile = new UserProfile
            {
                 UserId = new Guid().ToString(),
                 BranchId = userProfileVM.BranchId,
                 FirstName= userProfileVM.FirstName,
                 LastName = userProfileVM.LastName,
                 MobileNo= userProfileVM.MobileNo,
                 IsActive= userProfileVM.IsActive,
                 ResUserId= userProfileVM.ResUserId,
                 SystemDate= userProfileVM.SystemDate,
                 SetDate= userProfileVM.SetDate,
                 AspNetUser= userProfileVM.AspNetUser,
                 
            };

            unitOfWork.UserProfileRepository.Insert(UserProfile);
            unitOfWork.Save();
        }

        public void Update(UserProfileViewModel userProfileVM)
        {
            var UserProfile = new UserProfile
            {
                UserId = userProfileVM.UserId,
                BranchId = userProfileVM.BranchId,
                FirstName = userProfileVM.FirstName,
                LastName = userProfileVM.LastName,
                MobileNo = userProfileVM.MobileNo,
                IsActive = userProfileVM.IsActive,
                ResUserId = userProfileVM.ResUserId,
                SystemDate = userProfileVM.SystemDate,
                SetDate = userProfileVM.SetDate,
                AspNetUser = userProfileVM.AspNetUser,
             
            };


            unitOfWork.UserProfileRepository.Update(UserProfile);

            unitOfWork.Save();
        }


        public UserProfileViewModel GetByID(string id)
        {
            var data = (from s in unitOfWork.UserProfileRepository.Get()
                        where s.UserId == id
                        select new UserProfileViewModel
                        {
                            UserId = s.UserId,
                            BranchId = s.BranchId,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            MobileNo = s.MobileNo,
                            IsActive = s.IsActive,
                            ResUserId = s.ResUserId,
                            SystemDate = s.SystemDate,
                            SetDate = s.SetDate,
                            AspNetUser = s.AspNetUser,
                           


                        }).SingleOrDefault();

            return data;
        }

        public IEnumerable<UserProfileViewModel> GetAll()
        {
            var data = (from s in unitOfWork.UserProfileRepository.Get()
                        select new UserProfileViewModel
                        {
                            UserId = s.UserId,
                            BranchId = s.BranchId,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            MobileNo = s.MobileNo,
                            IsActive = s.IsActive,
                            ResUserId = s.ResUserId,
                            SystemDate = s.SystemDate,
                            SetDate = s.SetDate,
                            AspNetUser = s.AspNetUser,
                            

                        }).AsEnumerable();

            return data;
        }

    }
}
