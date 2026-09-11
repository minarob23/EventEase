# EventEase - Blazor Web Application

EventEase is an event management web application developed using Blazor WebAssembly and .NET 8, designed and refined using Microsoft Copilot.

## Features Implemented
- **Foundational Components:** Modular `EventCard.razor` with two-way parameter data binding.
- **Routing & Navigation:** Seamless parameterized navigation across `/events`, `/events/{id}`, and `/register/{id}` with a 404 fallback layout.
- **Debugging & Performance Optimization:** Defensive input guards on mutations and list virtualization using `<Virtualize>` with `@key` tracking for large datasets.
- **State Management:** Centralized `AppStateService` managing user authentication sessions, live attendance counts, and event registrations.
- **Form Handling:** Robust forms built using Blazor's `EditForm`, `DataAnnotationsValidator`, and regex email validation.

---

## Microsoft Copilot Assistance Summary

### Activity 1: Component Generation & Routing
- Scaffolded the initial `EventCard.razor` UI layout using Bootstrap card styles.
- Generated `@bind` two-way data binding syntax for instant field updates.
- Designed the navigation link hierarchy and route parameters (`/events/{Id:int}`).

### Activity 2: Debugging & Performance Optimization
- Identified boundary edge cases where invalid or empty input broke component state; suggested input validation handlers.
- Resolved routing crashes on non-existent IDs by suggesting defensive checks and an `App.razor` `<NotFound>` catch-all template.
- Optimized slow DOM rendering across large lists by replacing standard loops with Blazor's `<Virtualize>` component.

### Activity 3: Advanced Features & State Continuity
- Recommended a scoped `AppStateService` pattern with C# events (`OnChange`) to preserve user login sessions across page navigations.
- Scaffolded the `EditForm` with `DataAnnotationsValid~ator` and `ValidationSummary` for validated registration inputs.
- Implemented `IDisposable` event unhooking across components to guarantee zero memory leaks in production.