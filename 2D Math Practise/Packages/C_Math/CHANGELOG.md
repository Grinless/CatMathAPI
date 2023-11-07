# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
- Editor Test Improvements -> C_Vec2.VectorProjection.    (#I11)
- C_V2.Perpendicular.                                     (#I10)
- C_V2.Perpendicular.                                     (#I9)
- C_V2.Parallel.                                          (#I8)
- C_V3.Parallel.                                          (#I7)
- C_V3.AngleBetweenDeg.                                   (#I6)
- C_V2 Reflection Array.                                  (#I5)
- C_V2 Reflection.                                        (#I5)
- C_GaussJordanSolver.                                    (#I4)
- C_GaussMatrix.                                          (#I3)
- C_GaussSolver.                                          (#I2)
- C_Probability.                                          (#I1)

----
## [1.1.1] - 2023-11-06

### Added
- Added C_P2 -(C_P2D a, C_P2D b).                    (#A48)
- Added C_V2.Perpendicular(C_V2 a).                (#A48)
- Added C_V2.Perpendicular(C_V2 a, C_V2 norm).     (#A47)
- Added C_V2.Parallel(C_V2 a).                     (#A46)
- Added C_V2.Parallel(C_V2 a, C_V2 norm).          (#A45)
- Added C_V2.AngleBetweenDeg(C_V2 A, C_V2 B).      (#A43)
- Added C_V2 Operator Overload +(C_P2D, C_V2 vec)    (#A42)
- Added C_V2.GetLineMidpoint(C_P2D, C_V2 vec)        (#A41)
- Added C_V2.MidpointVec property.                   (#A40)
- Added C_V2.HalfMagnitude property.                 (#A39)

### Fixed
- Improved Editor Test -> C_Vec2.AngleBetweenRad(C_V2 A, C_V2 B).    (#F6)
- Improved C_V2.AngleBetweenRad(C_V2 A, C_V2 B).                   (#F6)
- Improved C_V2.ProjectionABMagnitude(C_V2 A, C_V2 B).             (#F5)
- Improved C_V2.ProjectionAB(C_V2 A, C_V2 B).                      (#F4)
- Improved C_V3.AngleBetweenRad(C_V2 A, C_V2 B).                   (#F6)

### Changed
- C_Point2D renamed to C_P2D. (#C2)

### Removed
- Removed C_V2 VectorDecompose (#R1)
----Superseeded by C_V2 Parallel/Perpendicular.
----

## [1.1.1] - 2023-11-06

### Added
- Added C_M2X2 Inverse Editor Unit Tests.             (#A38)
- Added C_M2X2 Adjoint Editor Unit Tests.             (#A37)

### Fixed
- Improved equality comparisons for C_M3X3/C_M2X2. (#F3)

### Changed
- C_V2/C_V3 UnityEngine conversion operator from implicit to explicit. (#C1)

### Removed

## [1.1.1] - 2023-11-06

### Added
- Added C_M2X2 Editor Unit Tests.             (#A36)
- Added C_M3X3 Editor Unit Tests.             (#A35)
- Added C_M4X4 Editor Unit Tests.             (#A34)
- Added C_V2 Editor Unit Tests.               (#A33)
- Added C_V3 Editor Unit Tests.               (#A32)
- Added C_Point2D Editor Unit Tests.          (#A31)
- Added C_Point3D Editor Unit Tests.          (#A30)
- Added C_Seq2 Editor Unit Tests.             (#A29)
- Added C_Seq3 Editor Unit Tests.             (#A28)
- Added C_Seq4 Editor Unit Tests.             (#A27)
- Added C_Seq5 Editor Unit Tests.             (#A26)
- Added Ishape Editor Unit Tests.             (#A25)
- Added C_Line Editor Unit Tests.             (#A24)
- Added C_Rect Editor Unit Tests.             (#A23)
- Added C_Triangle Editor Unit Tests.         (#A22)
- Added C_AABB Editor Unit Tests.             (#A21)
- Added C_Radial Editor Unit Tests.           (#A20)
- Added C_MathF Editor Unit Tests.            (#A19)

### Fixed

- Improved equality comparisons for C_M3X3/C_M2X2. (#F3)

### Changed
- C_V2/C_V3 UnityEngine conversion operator from implicit to explicit. (#C1)

### Removed
- Overtired implementation of equality operators (C_MathF.Greater/C_MathF.Lesser) (#R1)

## [1.1.1] - 2023-11-06

### Added
- Added C_M2X2.             (#A18)
- Added C_M3X3.             (#A17)
- Added C_M4X4.             (#A16)
- Added C_V2.               (#A15)
- Added C_V3.               (#A14)
- Added C_Point2D           (#A13)
- Added C_Point3D           (#A12)
- Added C_Seq2              (#A11)
- Added C_Seq3              (#A10)
- Added C_Seq4              (#A9)
- Added C_Seq5              (#A8)
- Added Ishape              (#A7)
- Added C_Line              (#A6)
- Added C_Rect              (#A5)
- Added C_Triangle          (#A4)
- Added C_AABB              (#A3)
- Added C_Radial            (#A2)
- Added C_MathF             (#A1)

### Fixed

- Improve C_M2X2/C_M3X3 multiplication operators (#F2).
- Improve C_Vec2 Normal Calculations. (#F1).

### Changed

### Removed
