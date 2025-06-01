---
applyTo: "**/*tsx,**/*.ts"
---

# Project coding standards for C#

Apply the [code-conventions-general.instructions.md](./code-conventions-general.instructions.md) to all code.
Apply the [code-conventions-typescript.instructions.md](./code-conventions-typescript.instructions.md) to all TypeScript code.

## React Code Conventions

1. Use functional components with hooks
2. Use TypeScript for type safety
3. Prefer arrow functions for component definitions
4. Use React 19 features: use, useActionState, useOptimistic
5. Use Suspense API for better UX

### Component Structure

1. Import external libraries first, then internal modules
2. Define interfaces/types before component for component props
3. Export component as default at the end
4. Use props destructuring in function parameters
5. Organize hooks at the top of component function
6. Export `ComponentName.displayName` for better debugging

### State Management

1. Use useState for local component state
2. Use useReducer for complex state logic
3. Use Context API for app-wide state when needed

### Styling Conventions

1. Follow BEM methodology for CSS classes

### Testing Conventions (React Testing Library + Vitest)

1. Test user behavior, not implementation details
2. Use `screen.getByRole()` over `getByTestId()` when possible
3. Use `userEvent` for user interactions
4. Mock external API calls and dependencies
5. Test accessibility and keyboard navigation
6. Use descriptive test descriptions
7. Use `it.each` for parameterized tests
8. Use `it('should ...', () => { ... })` for test cases
9. Use `beforeEach` for setup code
10. Use `afterEach` for cleanup code
11. Use `describe` blocks to group related tests
12. Use `expect` assertions for testing outcomes
