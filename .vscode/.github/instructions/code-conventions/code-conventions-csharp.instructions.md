---
applyTo: "**/*cs"
---

# Project coding standards for C#

Apply the [code-conventions-general.instructions.md](./code-conventions-general.instructions.md) to all code.

## C# Code Conventions

1. Prefer single `switch` statement over multiple (more than 2) `if` blocks
2. Always add braces for `if` and `for` blocks
3. Private class fields shall start with an underscore `_`, except for private class fields decorated with Unity `SerializeFieldAttribute`
4. Use explicit access modifiers (private, public, protected) for clarity.
5. Prefer `var` for local variable declarations when possible, except when the type is not obvious or when it improves readability.
6. Use `nameof` operator for property and method names to avoid hardcoding strings.
7. Use `string.Empty` instead of `""` for empty strings.
8. Use `StringBuilder` for string concatenation in loops or when building large strings.
9. Use `using` statements for disposable resources to ensure proper cleanup.
10. Use `async` and `await` for asynchronous programming to avoid blocking the main thread.
11. Use language pattern matching (`is`, `switch`, etc.) for cleaner and more readable code.
12. Use `IEnumerable<T>` for method return types when possible to allow for deferred execution and better performance.
13. Use `LINQ` for querying collections to improve readability and maintainability.
14. Use `Task` for asynchronous methods instead of `void` to allow for proper error handling and continuation.
15. Use `null` checks before accessing properties or methods to avoid `NullReferenceException`.
16. Use `??` operator for null-coalescing to provide default values.
17. Use `??=` operator for null-coalescing assignment to simplify code.

### C# Naming Conventions

    - Use PascalCase for type names
    - Use PascalCase for enum values
    - Use PascalCase for constants
    - Use camelCase for function and method names
    - Use camelCase for property names and local variables
    - Use camelCase for private fields, prefixed with an underscore `_`
    - Use whole words in names when possible
    - Use meaningful names that convey the purpose of the variable, method, or class
    - Use `I` prefix for interface names
    - Use `Async` suffix for asynchronous methods
    - Use `Get` prefix for methods that retrieve data
    - Use `Set` prefix for methods that modify data
    - Use `Try` prefix for methods that attempt an operation and return a boolean indicating success or failure
    - Use `On` prefix for event handler methods
    - Use `Handle` prefix for methods that handle events or messages

### C# Formatting Conventions

    - Use 4 spaces for indentation (no tabs)
    - Place opening braces on the new line for classes, methods, and control structures
    - Place closing braces on the new line
    - Use a single blank line to separate logical blocks of code
    - Use a single blank line to separate method definitions
    - Use braces for single-line `if`, `for`, and `while` statements
    - Use spaces around binary operators (e.g., `a + b`, not `a+b`)

### XUnit Testing Conventions

1. Use descriptive test method names: `Should_ReturnUser_When_ValidIdProvided`
2. Follow Arrange-Act-Assert pattern
3. Use `Theory` and `InlineData` for parameterized tests
4. Mock dependencies using NSubstitute
5. Test both positive and negative scenarios
6. Use `async Task` for async test methods
7. Use Shouldly for assertions to improve readability