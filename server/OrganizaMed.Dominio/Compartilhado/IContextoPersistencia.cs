﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizaMed.Dominio.Compartilhado;

public interface IContextoPersistencia
{
	Task<bool> GravarAsync();
}