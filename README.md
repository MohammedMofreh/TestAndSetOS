# TestAndSetOS
Test-and-Set is a synchronization primitive used in concurrent programming to implement mutual exclusion, ensuring that only one thread can access a critical section of code at a time. It consists of two parts: testing the current state of a flag or variable, and setting it to a new state if certain conditions are met.

# Implementation in C#:
In C#, the Interlocked class provides methods for performing atomic operations on variables.
The Interlocked.Exchange method is used here, which atomically sets a variable to a specified value and returns its original value.
By using Interlocked.Exchange, we achieve atomicity, ensuring that no other threads can interfere with the operation of testing and setting the lock.

# Explanation of Code:
We have a shared variable lockValue, which serves as the lock. When lockValue is 0, it indicates that the critical section is not currently being accessed, and when it's 1, it indicates that the critical section is locked.
The TestAndSet method atomically sets lockValue to 1 and returns its previous value. If the previous value was 0, it means the lock was successfully acquired.
In the Main method, we attempt to acquire the lock using TestAndSet.
If the return value is 0, we enter the critical section, perform the required operations, and then release the lock by setting lockValue back to 0.
If the return value is 1, it means the resource is currently locked, and we handle this case accordingly (in this example, just printing a message).

# Thread Safety:
This implementation ensures thread safety by using atomic operations provided by Interlocked.Exchange.
It prevents race conditions where multiple threads might try to access the critical section simultaneously.
Only one thread can successfully acquire the lock at a time, ensuring mutual exclusion and safe concurrent access to shared resources.
By using Test-and-Set in this way, you can safely coordinate access to critical sections of code in a multithreaded environment.
