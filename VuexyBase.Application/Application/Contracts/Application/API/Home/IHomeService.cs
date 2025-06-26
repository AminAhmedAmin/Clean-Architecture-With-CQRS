using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Application.Application.Contracts.Application.API.Home
{
    public interface IHomeService
    {
        Task SaveIncludeAsync(ApplicationDbUser entity, params string[] properties);


    }
}
