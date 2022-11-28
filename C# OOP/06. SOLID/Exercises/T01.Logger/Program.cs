using T01.Logger.Appenders.Interfaces;
using T01.Logger.Appenders;
using T01.Logger.Layouts.Interfaces;
using T01.Logger.Layouts;
using T01.Logger.Loggers.Interfaces;
using T01.Logger.Loggers;
using T01.Logger.Enumerations;
using T01.Logger.Factory;

namespace T01.Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();
            ILogger logger = new Loggers.Logger();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] appendersInfo = Console.ReadLine().Split();
                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                ILayout layout = layoutFactory.Create(layoutType);

                IAppender appender = appenderFactory.Create(appenderType, layout);

                if (appendersInfo.Length == 3)
                {
                    bool isValidReportLevel = Enum.TryParse(appendersInfo[2], true, out ReportLevel reportLevel);
                    if (isValidReportLevel)
                    {
                        appender.ReportLevel = reportLevel;
                    }
                }
                logger.Appenders.Add(appender);



            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] messageInfo = command.Split('|');
                string reportLevel = messageInfo[0];
                string date = messageInfo[1];
                string message = messageInfo[2];
                bool isValidReportLevel = Enum.TryParse(reportLevel, true, out ReportLevel reportLevell);
                if (!isValidReportLevel)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (reportLevell == ReportLevel.Info)
                {
                    logger.Info(date, message);
                }
                else if (reportLevell == ReportLevel.Error)
                {
                    logger.Error(date, message);
                }
                else if (reportLevell == ReportLevel.Critical)
                {
                    logger.Critical(date, message);
                }
                else if (reportLevell == ReportLevel.Warning)
                {
                    logger.Warning(date, message);
                }
                else if (reportLevell == ReportLevel.Fatal)
                {
                    logger.Fatal(date, message);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(logger.ToString());
        }
    }
}