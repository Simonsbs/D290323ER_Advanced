using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo;
public static class StringExtensions {
	public static string FirstLetterToUpper(this string input) {
		if (string.IsNullOrEmpty(input)) {
			return input;
		}

		return char.ToUpper(input[0]) + input.Substring(1);
	}

	public static string ReturnAWord<T>(this IEnumerable<T> input) {
		return "WORD!";
	}

	public static bool IsMT(this string input) {
		return string.IsNullOrEmpty(input);
	}
}
