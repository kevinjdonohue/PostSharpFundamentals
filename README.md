# PostSharp Fundamentals
Some example code and notes created while taking the PostSharp Fundamentals course on PluralSight.

## Aspect Oriented Programming

Overview of Aspect Oriented Progamming (AOP).

### What is it?
- Managing code in "cross cutting" concerns

- Increasing the modularity of our codebase

- Composition of code infrastructure concerns

- Examples:  Autiting, Logging, Security (Authentication Authorization), Perf. Monitoring, etc.

### Why would you use it?

- Reduce code duplication

- Keep code singly responsible (SRP - S in SOLID)

- DRY code

- Modularity

### How can you apply it?

- Two main ways:  Interceptors and IL Weaving

  - Interceptors:  

    - Basic Decorator Pattern

    - Commonly implemented through IoC containers

  - IL Weaving:

      - Much more complex possibilities

      - Requires a post compile step

      - PostSharp is an example of an IL Weaving AOP framework
