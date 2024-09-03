
# Commit Conventions
We follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) to write the commit messages.
The commit message should be structured as follows:

```
<type>: <subject>
empty separator line
<optional body>
empty separator line
<optional footer>

```

# Type
Type must be one of the following:

- **bug**: Something isn't working
- **documentation**: Improvements or additions to documentation
- **duplicate**: This issue or pull request already exists
- **feature**: New feature or request
- **formatting**: style, intendency, .etc
- **help wanted**: Extra attention is needed
- **question**: Further information is requested
- **refactor**: Code refactoring
- **test**: request for test, wring test, testing overally
- **won`t fix**: This will not be worked on
  
## Subject
The subject contains a succinct description of the change.

- Is a mandatory part of the format
- Use the imperative, present tense: "change" not "changed" nor "changes"
- Don't capitalize the first letter
- No dot (.) at the end

## Body
The body should include the motivation for the change and contrast this with previous behavior.

- Is an optional part of the format
- Use the imperative, present tense: "change" not "changed" nor "changes"

## Footer
The footer is the place to reference Issues that this commit refers to.

- Is an optional part of the format
- optionally reference an issue by its id.

## Examples

```
feat: display cards of the same type next to each other

This feature change the card's sorting behavior to diplay cards of the same type next to each other. 

refers to issue #15

```

```
style: remove empty line

```

```
fix: add missing parameter to service call

The error occurred because of <reasons>.

```
Accepted from [hamed-shirband](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/Commit-Conventions.md)
