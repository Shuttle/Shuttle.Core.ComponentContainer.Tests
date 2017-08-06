namespace Shuttle.Core.ComponentContainer.Tests
{
	public class MultipleImplementation : 
		IMultipleImplementation<string>,
		IMultipleImplementation<int>
	{
	}
}