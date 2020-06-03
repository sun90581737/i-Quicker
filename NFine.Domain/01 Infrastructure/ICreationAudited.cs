/*******************************************************************************
 * Copyright © 2016
 * 
 * Description: MVC快速开发平台
 *
*********************************************************************************/
using System;

namespace NFine.Domain
{
    public interface ICreationAudited
    {
        string F_Id { get; set; }
        string F_CreatorUserId { get; set; }
        DateTime? F_CreatorTime { get; set; }
    }
}