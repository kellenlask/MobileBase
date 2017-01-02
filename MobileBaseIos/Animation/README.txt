Design Considerations:
{
- Bundle target views with the Animation, or the AnimationSet?
    - More dynamic is to atomize animation operations in their entirety which can be used to perfectly emulate using a target on the AnimationSet
        - Use null-checks and allow for the specification of a target view on the AnimationSet? -- Skip any Animation with a null view...
    - It's probably more dynamic to include the target view with the animation, especially if we're thinking of animations in a monadic sense where you manage animations as compositions of operations.
    - Particularly with sequential animations, if you can apply to sibling views you can easily do things like sequential bounces (like in the Aspen app)
}{
- Separate out the concurrent and sequential AnimationSets? They basically do the same thing...
    - How expensive is it to construct an AnimationGroup?
        - Not very.
    - Is there something lost in using functional application to determine the AnimationSet type?
        - If anything, there's a massive benefit of set interoperability...
}{
- Sequential AnimationSets require a duration -- use an argument? (Yes)
}{
- Abstract away the time/value step arrays? These are more adaptable as functions...
    - SetStep(steps, funcGetVal) -> AnimationSet
}{
- How should Timing Functions be handled?
    - A custom step function + a linear timing function allows for using step functions to control the animation's curve
    - Supporting the standard timing functions allows for brute-forcing animations by linear stepwise specification and adjusting the curve of the timing function.
}{
- Do I need this concept of a basic Animator that performs a similar function to UIView.Animate(...)?
    - This "PropertyAnimator" is basically a special case of the standard CAKeyFrameAnimation-based Animator.
    - UIView.Animate(...) is not concurrent.
    - Breaks with the monadic concept and requires a bunch of Interface-based Tom-foolery to get operational.
    - UIView.Animate(...) is so easy to use that anyone wanting to use it should just opt to use it.
    - They can handle the interfacing Tom-foolery to get it operational should they want.
}{
- How should the Animation Keys be handled? Ideally, the key name is equal to the animated property's name...
    - GUID
    - Reflection

}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
}{
