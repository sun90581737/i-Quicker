/*******************************************************************************
 * Copyright © 2016
 * 
 * Description: MVC快速开发平台
 *
*********************************************************************************/
using System;

namespace NFine.Domain
{
    public interface IModificationAudited
    {
        string F_Id { get; set; }
        string F_LastModifyUserId { get; set; }
        DateTime? F_LastModifyTime { get; set; }
    }
}