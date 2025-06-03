# civil3d
JBD Software's open source tools for Civil 3D


/JbdPlugin.Template/                            # Root solution folder for your plugin

├── Domain/                                     # Shared enterprise domain models (only if reused across features)
│   ├── Common/                                 # Generic business primitives (e.g., Measurement, Quantity)
│   └── Geometry/                               # Shared geometric concepts (Point3D, BoundingBox, etc.)

├── Features/                                   # Vertical slices – each folder is one full feature/module
│   ├── ExportFloodTIN/                         # Example slice – fully self-contained

│   │   ├── Core/                               # Core logic for this feature (use cases, business rules)
│   │   │   ├── Interactors/                    # Application logic: orchestrates feature behavior
│   │   │   │   ├── Commands/                   # Stateful operations (e.g., export, modify, save)
│   │   │   │   ├── Queries/                    # Read-only use cases (e.g., preview data, count items)
│   │   │   │   └── Events/                     # Event-driven logic, if applicable (e.g., OnSurfaceChanged)

│   │   │   ├── Interfaces/                     # Contracts this slice depends on (e.g., `ICivil3DReader`)
│   │   │   └── Models/                         # Domain-like models scoped to this feature only
│   │   │   └── Validators/                     # Input validation, possibly using FluentValidation or manual logic

│   │   ├── Infrastructure/                     # Technology-facing code, implements interfaces in Core
│   │   │   ├── Civil3D/                        # Direct interaction with AutoCAD/Civil 3D APIs
│   │   │   │   ├── Readers/                    # Read from Civil 3D (e.g., TIN surface, polylines)
│   │   │   │   ├── Writers/                    # Write back to Civil 3D (e.g., draw labels, surfaces)
│   │   │   │   ├── Mappers/                    # Converts Civil 3D data to internal models
│   │   │   │   └── Extensions/                 # Extension methods to enhance CAD types safely
│   │   │   ├── Persistence/                    # Any file/DB storage local to this slice
│   │   │   │   ├── Repositories/               # Implements persistence interfaces
│   │   │   │   └── Storage/                    # File access, I/O utilities, maybe JSON/CSV
│   │   │   └── Services/                       # Optional service wrappers (e.g., AutoCAD transactions, loggers)

│   │   ├── Presentation/                       # Entry point and UI layer for this slice
│   │   │   ├── Commands/                       # AutoCAD `[CommandMethod]` classes (like `EXPORTFLOODTIN`)
│   │   │   ├── UI/                             # UI-specific logic (WPF/WinForms/WinUI)
│   │   │   │   ├── Views/                      # Actual forms/windows/pages shown to the user
│   │   │   │   └── ViewModels/                 # MVVM-style binding logic (e.g., data-bound models)
│   │   │   └── Resources/                      # XAML, images, icons, theme resources

│   │   ├── Composition/                        # Local DI + composition setup (optional per slice)
│   │   │   └── DependencyInjection/            # Registers services and interfaces for this slice

│   │   └── Tests/                              # All tests scoped to this slice
│   │       ├── Unit/                           # Unit tests for handler, mappers, validators
│   │       └── Integration/                    # Integration tests (e.g., Civil 3D round-trips)

├── Infrastructure/                             # Global implementation-level services
│   ├── Logging/                                # Logging adapters (e.g., Serilog, NLog)
│   ├── Configuration/                          # App config reader, environment handling
│   └── CompositionRoot/                        # Registers all slices and services into DI container

├── Shared/                                     # Globally reusable helpers, adapters, utilities
│   ├── AutoCAD/                                # Helpers for common AutoCAD tasks (selection, layers)
│   ├── Utilities/                              # Math, strings, geometry conversions
│   ├── Geometry/                               # CAD-safe utility math (e.g., cross product, normal vector)
│   └── Interfaces/                             # Interfaces reused across many slices (e.g., `ILogger`, `IPrinter`)

└── EntryPoints/                                # Optional: Global command entry if not using slice-located commands
    └── Commands/                               # Flat namespace for `[CommandMethod]` classes if preferred
