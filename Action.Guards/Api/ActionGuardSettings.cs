using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Guards.Api
{
    public class ActionGuardSettings
    {
        public bool ExceptionModel_ShowClassName { get; set; } = false;
        public bool ExceptionModel_ShowMessage { get; set; } = false;
        public bool ExceptionModel_ShowStackTrace { get; set; } = false;
        public bool ExceptionModel_ShowInnerExceptions { get; set; } = false;
    }
}
