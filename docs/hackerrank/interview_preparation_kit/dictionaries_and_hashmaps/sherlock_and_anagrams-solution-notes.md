# [Sherlock and Anagrams](https://www.hackerrank.com/challenges/sherlock-and-anagrams)

- Difficulty:  `#medium`
- Category: `#ProblemSolvingMedium` `#DictionariesAndHashmaps` `#Strings`

## About solution

To answer the question of "how many pairs" of words can be anagrammed
using fragments from adjacent letters of an initial word, two steps are needed:

1) Obtain all possible fragment candidates to be anagrams,
  from each of the possible fragments that can be generated
  from adjacent letters of a word.

2) For each list of candidate anagrams,
  calculate all possible permutations and add them up.
  The total gives the answer.

The second part of this problem can be solved with the binomial coefficient formula:

<https://en.wikipedia.org/wiki/Binomial_coefficient>

But the entire cost of this formula falls on the "factorial" function.

The factorial quickly reaches results that return large numbers,
overflowing the length of primitive number types.

To avoid this problem in C#, it is necessary to introduce large number handling
using System.Numerics.BigInteger
