using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Infrastructure.DataMapping;
using Infrastructure.SQLERepository;
using System.Linq;
namespace Services.Implementation.SQL
{
    public class ModuleServiceSQL : IModuleService
    {
        public RegisteredModule Create(CreateModule newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                var eModule = newRegistry.ToEntity();
                helpDeskDataContext.Modules.Add(eModule);
                helpDeskDataContext.SaveChanges();
                return eModule.ToDTO();
            }

        }

        public RegisteredModule Delete(DeletedModule Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredModule> List()
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Modules.ToList().Select(x => x.ToDTO()).ToList();
            }
        }

        public RegisteredModule Update(UpdateModule updateRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
