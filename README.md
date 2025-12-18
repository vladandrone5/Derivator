# Derivator
A simple symbolic differentiator that transforms the input (given as a "prefix" expression) into a result differentiated "prefix" expression.

## How to:
1. Make sure you have the .NET extension (`brew install dotnet`)
2. Run with `dotnet run`
3. * insert an input prefix expression (e.g ['sin', 'x'])
   * insert the variable in respect to which you're differentiating (e.g x)
4. It should display a new prefix expression that is the result of the differentiation

## The logic behind:
* The input is given as a string in the form of `['op', operand1, operand2]`, where operand can be a string or a new prefix expression
* Then, the Parser.cs processes the input string into a `List<object>` object.
* The Differentiator.cs computes the derivative of the expression, and its components (in case there are other expressions inside)
* The result is printed by `PrintTree` function that "reconstructs" the result list into a string that is also a prefix expression.

### Examples of testing:

1. for input_string = `['+', 'x', '5']` and var = `x` -> output = `['+', '1', '0']`
2. for input_string = `['^', 'x', '2']` and var = `x` -> output = `['*', '1', ['*', '2', ['^', 'x', 1]]]`
3. for input_string = `['sin', ['^', 'x', '2']]` and var = `x` -> output = `['*', ['cos', ['^', 'x', '2']], ['*', '1', ['*', '2', ['^', 'x', 1]]]]`