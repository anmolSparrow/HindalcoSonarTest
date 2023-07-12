using System.Runtime.CompilerServices;


namespace DynamicSqlCreation
{
    /// <summary>
    /// Creates a custom logger with given configurations.
    /// </summary>
    internal static class LogHelper
    {
        /// <summary>
        /// Creates a custom logger with given filename.
        /// </summary>
        /// <param name="filename">source file name</param>
        /// <returns>Returns a custom logger for the given source file.</returns>
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}