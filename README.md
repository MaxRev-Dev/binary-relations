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
	Matrix type check
	- IsFullRelation
	- IsAntiDiagonalRelation
	- IsDiagonalRelation
	Helpers
	- Cast<R,T>
	- PrintThrough<T>

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
