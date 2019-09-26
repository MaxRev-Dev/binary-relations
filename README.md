# binary-relations [![Build Status](https://travis-ci.com/MaxRev-Dev/binary-relations.svg?token=K65jepPpym4puMzHhp9H&branch=master)](https://travis-ci.com/MaxRev-Dev/binary-relations)
Binary relations and matrix extensions library targeting netstandard2.0

Provides a bunch of extension methods for binary matrices including: 

## Binary matrix extensions
	Operations
	- Reverse
	- SymmetricDifference
	- Difference
	- Union
	- Intersection
	- Complementation
	- Dual
	- Narrowing
	- TransitiveClosure
	- ReflexiveClosure
	- SymmetricClosure
	- GetDiagonalRelation - a diagonal matrix 
	Matrix properties check
	- IsTotalRelation (full relation)
	- IsAntiDiagonalRelation
	- IsDiagonalRelation
	- IsReflexive
	- IsAntireflexive
	- IsSymmetric
	- IsAsymmetric
	- IsAntisymmetric
	- IsTransitive
	- IsNonTransitive
	- IsNegativeTransitive
	- IsAcyclic
	- IsConnex
		and derivative methods ...
	Extremums
	- HasMaximum() <-> HasMinimum()
	- HasMajorants() <-> HasMinorants()
		and corresponding getters ...  
	Helpers (for one and two dimentional arrays)
	- Cast<R,T>
	- Fill<T>(T value)
	- PrintThrough<T>
	- IsReferenceSequenceEqualTo<T>(T[] array)

## Matrix extensions 
	For arrays, vectors and numbers
	- Multiply
	- MultiplyRecursively
	- Add
	- Subtract
	- Power
	- Transpose
	Getters and setters for collumns and rows
	- GetRow<T>
	- SetRow<T>
	- GetCol<T>
	- SetCol<T>

## Helpers for matrices and arrays
	- Randomize
	- AllocateRandomSquareMatrix
	- AllocateRandomVector
