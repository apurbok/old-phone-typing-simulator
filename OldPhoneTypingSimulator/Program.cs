using System.Text;
using System.Text.RegularExpressions;

namespace OldPhoneTypingSimulator
{
    /// <summary>
    /// Class <c>OldPhone</c> represents an old phone device.
    /// </summary>
    class OldPhone
    {
        /// <summary>
        /// Method <c>OldPhonePad</c> generates the output text for old phone button's input symbol sequence.
        /// </summary>
        /// <param name="input">the input sequence containing the number/symbols of the phone buttons.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the provided input doesn't match with the requirement.
        /// </exception>
        public static string OldPhonePad(string input)
        {
            var inputPattern = @"^[0-9* ]*#";

            if (!Regex.Match(input, inputPattern).Success)
            {
                throw new ArgumentException("Input value should contain only numbers, * and space with an ending #.");
            }

            var outputBuilder = new StringBuilder();
            var prevInput = ' ';
            var prevInputCount = 0;

            for(var i = 0; i < input.Length; i++)
            {
                var currentInput = input[i];

                var isNumberEnded = currentInput == ' ' || currentInput == '#' || currentInput == '*' || currentInput == '0';
                if (isNumberEnded || (IsNonZeroDigit(prevInput) && IsNonZeroDigit(currentInput) && prevInput != currentInput))
                {
                    if (IsNonZeroDigit(prevInput))
                    {
                        outputBuilder.Append(ButtonToCharMapping(prevInput, prevInputCount));
                    }

                    if (currentInput == '*' && outputBuilder.Length > 0)
                    {
                        outputBuilder.Remove(outputBuilder.Length - 1, 1);
                    }
                    else if (currentInput == '0')
                    {
                        outputBuilder.Append(' ');
                    }

                    prevInputCount = IsNonZeroDigit(currentInput) ? 0 : -1;
                }


                prevInput = currentInput;
                prevInputCount++;
            }


            return outputBuilder.ToString();
        }


        //Region: Private Methods
        private static bool IsNonZeroDigit(char ch)
        {
            return ch > '0' && ch <= '9';
        }


        /// <summary>
        /// Method <c>ButtonToCharMapping</c> generates corresponding output character for old phone button's symbol/digit.
        /// </summary>
        /// <param name="btnSymbol">the pressed button's input symbol/digit as character.</param>
        /// <param name="clickCount">the count of button pressing event.</param>
        private static char ButtonToCharMapping(char btnSymbol, int clickCount)
        {
            if (btnSymbol == '1')
            {
                switch((clickCount - 1) % 3)
                {
                    case 0:
                        return '&';
                    case 1:
                        return '\'';
                    case 2:
                        return '(';
                }
            }

            var btnStartingChar = (btnSymbol - '2') * 3;
            var btnCharsCount = 3;

            if (btnSymbol == '7' || btnSymbol == '9')
            {
                btnCharsCount++;
            }

            if (btnSymbol > '7')
            {
                btnStartingChar++;
            }


            return (char)('A' + btnStartingChar + (clickCount - 1) % btnCharsCount);
        }
    }


    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please write an input text simulating old phone button clicks." +
                    " Input should be a text with any number of 0-9 digits, space, * and an ending #. ie. (112# or 11  1100*#):" +
                    "\n(To exit, please provide \'exit\' command)\n");

                var userInput = Console.ReadLine() ?? "#";
                
                if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you!");
                    break;
                }

                try
                {
                    Console.WriteLine(OldPhone.OldPhonePad(userInput));
                } catch(ArgumentException ex)
                {
                    Console.WriteLine($"Exception occured while processing the input.\nDetails: {ex.Message}");
                } catch(Exception ex)
                {
                    Console.WriteLine($"An unknown exception has occurred.\nDetails: {ex.Message}");
                }
            }
        }
    }
}