using Quantum;
using Quantum.Operations;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace QuantumConsole
{
	public class QuantumTest
	{
		public static void Main()
		{
			QuantumComputer comp = QuantumComputer.GetInstance();
			Register x = comp.NewRegister(0, 3);
			Register y = comp.NewRegister(1, 1);
			y.Hadamard(0);
			x.Hadamard(0);
			x.Hadamard(1);
			x.Hadamard(2);

			// Grover Iteration
			comp.Toffoli(y[0], x[0], x[1], x[2]);		// Toffoli(<target_bit>, ... <control_bits> ...)
			comp.Walsh(x);
			x.SigmaX(0);
			x.SigmaX(1);
			x.SigmaX(2);
			x.Hadamard(0);
			comp.Toffoli(x[0], x[1], x[2]);		// oracle
			x.Hadamard(0);
			x.SigmaX(0);
			x.SigmaX(1);
			x.SigmaX(2);
			comp.Walsh(x);
			
			// Grover Iteration
			comp.Toffoli(y[0], x[0], x[1], x[2]);		// Toffoli(<target_bit>, ... <control_bits> ...)
			comp.Walsh(x);
			x.SigmaX(0);
			x.SigmaX(1);
			x.SigmaX(2);
			x.Hadamard(0);
			comp.Toffoli(x[0], x[1], x[2]);		// oracle
			x.Hadamard(0);
			x.SigmaX(0);
			x.SigmaX(1);
			x.SigmaX(2);
			comp.Walsh(x);
			
			
			y.Measure(0);
			x.Measure(0);
			x.Measure(1);
			x.Measure(2);
		}
	}
}

