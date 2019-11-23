using System;
using System.Collections.Generic;
using NDesk.Options;

namespace Sorc {
    static class Args {
        public static bool help = false;
        public static int exst = 0;
        public static string[] vale_il_files;

        private static OptionSet _parser = new OptionSet {
            {
                "h|help", "show this message and exit",
                v => {
                    help = v != null;
                    exst = 0;
                }
            }
        };

        private static void _ShowHelp(OptionSet parser) {
            Console.WriteLine("usage: " +
                $"{System.AppDomain.CurrentDomain.FriendlyName} " +
                "[OPTIONS]+ VALE_IL_FILE [VALE_IL_FILE...]");
            Console.WriteLine();
            Console.WriteLine("converts Vale IL to MS CIL");
            Console.WriteLine();
            Console.WriteLine("positional arguments:");
            Console.WriteLine(
                "  VALE_IL_FILE               path to Vale IL file");
            Console.WriteLine();
            Console.WriteLine("optional arguments:");
            parser.WriteOptionDescriptions(Console.Out);
        }

        private static void _ConsumePositionalArgs(List<string> args) {
            if (args.Count < 1) {
                help = true;
                exst = 1;
            }
            vale_il_files = args.ToArray();
        }

        public static void Parse(string[] args) {
            List<string> pos = _parser.Parse(args);
            _ConsumePositionalArgs(pos);

            if (help) {
                _ShowHelp(_parser);
                Environment.Exit(exst);
            }
        }
    }
}
