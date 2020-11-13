﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Declarations.Common
{
    public interface ICRUDService<DTOCreate, DTOUpdate, DTORegistered, DTODelete>
    {
        DTORegistered Create(DTOCreate newRegistry);
        List<DTORegistered> List();
        DTORegistered Update(DTOUpdate updateRegistry);
        DTORegistered Delete(DTODelete Id);
    }
}
