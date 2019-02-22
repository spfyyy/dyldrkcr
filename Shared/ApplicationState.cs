using Shared.Models;

namespace Shared
{
    public class ApplicationState
    {
        /// <summary>
        /// The current login session.
        /// </summary>
        public Session Session { get; set; }
    }
}
