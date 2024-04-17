# WA.XTEMPLATEX

<hr/>

## Technical Notes


### ValueTask as used in Handler return types
	
Tasks are references allocated to The Heap.  We label a return type as a async Task<T> in order to permit awaiting for other operations to complete.  Most often, the actual return will be just a T.

ValueTasks are Discriminated Unions which can represent one of two things: <T> or Task<T>.  This means we can still return an actual Task<T> or avoid allocating Heap memory for a Task when methods' await minor operations, such as checking a cache.

<hr/>