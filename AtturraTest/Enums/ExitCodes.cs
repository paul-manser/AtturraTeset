using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTeset.Enums
{
    [Flags]
    enum ExitCodes : int
    {
        Success = 0,
        SignToolNotInPath = 1,
        AssemblyDirectoryBad = 2,
        PFXFilePathBad = 4,
        PasswordMissing = 8,
        SignFailed = 16,
        UnknownError = 32,
        UnhandledException = 64
    }
}
