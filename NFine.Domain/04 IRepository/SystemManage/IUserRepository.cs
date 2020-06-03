/*******************************************************************************
 * Copyright © 2016
 * 
 * Description: MVC快速开发平台
 *
*********************************************************************************/
using NFine.Data;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
    }
}
