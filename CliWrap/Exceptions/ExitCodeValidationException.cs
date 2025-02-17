﻿using System.Text;
using CliWrap.Models;

namespace CliWrap.Exceptions
{
    /// <summary>
    /// Thrown if underlying process reported a non-zero exit code.
    /// </summary>
    public partial class ExitCodeValidationException : ExecutionResultValidationException
    {
        /// <summary>
        /// Exit code reported by the underlying process.
        /// </summary>
        public int ExitCode => ExecutionResult.ExitCode;

        /// <summary>
        /// Initializes an instance of <see cref="ExitCodeValidationException"/>.
        /// </summary>
        public ExitCodeValidationException(ExecutionResult executionResult)
            : base(executionResult, CreateExceptionMessage(executionResult))
        {
        }
    }

    public partial class ExitCodeValidationException
    {
        private static string CreateExceptionMessage(ExecutionResult executionResult)
        {
            var buffer = new StringBuilder();
            buffer.AppendLine("Underlying process reported a non-zero exit code.")
                .AppendLine()
                .Append("Exit code: ").Append(executionResult.ExitCode).AppendLine()
                .AppendLine()
                .AppendLine("Standard error:")
                .AppendLine(executionResult.StandardError);

            return buffer.ToString();
        }
    }
}