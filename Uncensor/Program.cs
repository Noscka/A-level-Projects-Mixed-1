﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncensor
{
	internal class Program
	{
		const string Vowels = "aeiou";

		/// <summary>
		/// Puts vowels in the place of *
		/// </summary>
		/// <param name="censored">the string with censored vowels</param>
		/// <param name="vowels">the vowels to be put back</param>
		/// <returns>uncensored string</returns>
		static string Uncensor(string censored, string vowels)
		{
			/* check if the input vowel string is all actually vowels */
			foreach (char vowel in vowels)
			{
				if (!Vowels.Contains(vowel))
				{
					return "error, non-vowel present";
				}
			}

			if(censored.Count(a => a == '*') != vowels.Length)
			{
				return "error, asterisks and vowel count not matching";
			}

			StringBuilder censoredBuilder = new StringBuilder(censored); /* Converted to String builder to allow changing the values at indexes */
			int VowelIndex = 0; /* tracks the index that the vowel will get taken from  */

			for(int i = 0; i< censoredBuilder.Length; i++)
			{
				if(censoredBuilder[i] == '*')
				{
					censoredBuilder[i] = vowels[VowelIndex];
					VowelIndex++;
				}
			}

			return censoredBuilder.ToString();
		}

		static void Main(string[] args)
		{
			Console.WriteLine(Uncensor("*d*m", "aa"));
		}
	}
}
