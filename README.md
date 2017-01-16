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

## Post Sharp

### Installation & Setup

- Can either install via MSI/EXE or NuGet (most popular)
- Licenses - for larger organizations consider setting up license server (ala Resharper)

### Out of the box Aspects

Starting point for aspect development.

- Existing Aspects built into PostSharp
- Majority use overrides to provide advices to the target ```
- Decorator pattern is everywhere

#### OnMethodBoundaryAspect

This is a method level apsect.  There are a number of "point cuts" that can be implemented for a method level aspect.

- Point Cuts:
  - ```OnEntry```
  - ```OnExit```
  - ```OnException```
  - ```OnSuccess```
- Maps to a full decorator pattern implementation when all four (4) overrides are used

Structure of the OnMethodBoundaryAspect:

    ...

    {
        OnEntry();

        try
        {
            TargetCode();
            OnSuccess();
        }
        catch (Exception ex)
        {
            OnException();
        }
        finally
        {
            OnExit();
        }
    }

    ...

#### MethodExecuteArgs Class

Three (3) items that you will commonly interact with that come from the MethodExecuteArgs class.

- Arguments
  - List of value being passed to the target method
  - List of object values; not names or properties of the parameters (distinct from Parameters)
- Method
  - Meta-data information about the target
    - ex. GetParameters() - returns meta-data about the parameters
  - Reflection-based
- ReturnValue
  - Null if method is Void
