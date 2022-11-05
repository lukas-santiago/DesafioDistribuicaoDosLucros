namespace Application.Errors;
public class NotFoundException : Exception { }
public class AlreadyExistsException : BaseException { }
public abstract class BaseException : Exception { }