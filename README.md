# RomanNumerals

## Instructions

Write a program to convert Arabic numbers into their Roman numeral equivalents.

## Getting Started

Your solution should contain one method similar to:

public string Map(int amount)
Here, amount represents the Arabic number and the value this method returns is the string of Roman numerals.

## Tips

- Take small steps. You should always be able to go to a green state (with all tests passing) quickly.
- Stick to the red, green and refactor steps.
- Try not to refactor in the red. If you write a failing test that would need a big rewrite to pass, consider removing the test, refactoring in the green, and then writing the test again.
- As you progress through the problem, you should see your algorithm start to evolve. In other words, as the tests get more specific, the code gets more generic.
- Don't be afraid to let the code get a little bit messy - sometimes that's the best way to spot the next refactoring step.

## Context

The Romans wrote their numbers using combinations of the following letters:

|Number|Numeral|
|------|-------|
|1|I|
|5|V|
|10|X|
|50|L|
|100|C|
|500|D|
|1000|M|

Initially, the Roman Numerals system consisted of expressing the number in terms of the most appropriate symbol that could be used.

To start, for the numbers 1-4, we would use the 'I' symbol in multiples to represent the number:

|Number|Numeral|
|------|-------|
|1|I|
|2|II|
|3|III|
|4|IV|


When the numbers got to 5, we would use 'V' as this symbol was the most efficient way to represent the number.


|Number|Numeral|
|------|-------|
|5|V|

More examples:

|Number|Numeral|
|------|-------|
|29|XXIX|
|80|LXXX|
|294|CCXCIV|
|2019|MMXIX|
