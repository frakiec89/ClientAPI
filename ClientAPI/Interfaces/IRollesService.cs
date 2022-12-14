using System.Collections.Generic;

namespace ClientAPI.Interfaces
{
    public interface IRollesService
    {
        List<string> GetRolles(string tokken);
    }
}