using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07.ConsoleApp.Guided
{
	// EncapsulationDemo_Guided.cs
	// Guided exercise: Refactor public fields into private fields + properties.

	using System;

	// ❌ Starting point: Public fields (no encapsulation)
	public class BankAccountPublic
	{
		public string AccountNumber;
		public decimal Balance;
	}

	// ✅ Refactor this into an encapsulated version
	public class BankAccount
	{
		// TODO: Add a private backing field for balance (decimal)

		// TODO: Create a public read-only property for AccountNumber
		// - Set this in the constructor only

		// TODO: Create a public property for Balance
		// - Getter returns the private field
		// - Private setter validates that balance is not negative

		// TODO: Write a constructor that takes accountNumber and initialBalance
		// - Validate accountNumber is not null/whitespace
		// - Set AccountNumber and Balance (use property to trigger validation)

		// TODO: Write a Deposit(decimal amount) method
		// - Amount must be positive
		// - Increase Balance by amount

		// TODO: Write a Withdraw(decimal amount) method
		// - Amount must be positive
		// - Amount must not exceed Balance
		// - Subtract amount from Balance
	}

	public class EncapsulationExercise
	{
		public static void Main()
		{
			Console.WriteLine("=== Encapsulation Demo (Guided) ===");

			// ❌ Using public fields: no protection
			var accountPublic = new BankAccountPublic();
			accountPublic.AccountNumber = "12345";
			accountPublic.Balance = -5000; // ❌ Allowed! Invalid state.
			Console.WriteLine($"[Public] Account: {accountPublic.AccountNumber}, Balance: {accountPublic.Balance}");

			Console.WriteLine();

			// ✅ TODO: Create a BankAccount object with encapsulation
			// - Use the constructor to set account number and initial balance
			// - Print the account details using the properties

			// ✅ TODO: Test your Deposit and Withdraw methods
			// - Deposit a valid amount, print balance
			// - Withdraw a valid amount, print balance
			// - Try to deposit or withdraw invalid amounts and see exceptions
		}
	}


}
