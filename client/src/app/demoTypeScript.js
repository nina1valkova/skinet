// union type
var message = "Hello";
//can be without ttype
message = "Hello again";
//compiler stop me from doin this
//message = false;
var isComplete = false;
var todos = [];
//explicity call what funtion will return : Todo i mut return Todo from function
function addTodo(title) {
    var newTodo = {
        id: todos.length + 1,
        title: title,
        completed: false
    };
    // if it was JavaScipt is possible to let ne to write todos.push(todo);
    todos.push(newTodo);
    return newTodo;
}
function toggleTodo(id) {
    var todo = todos.find(function (todo) { return todo.id == id; });
    //TypeScript gives error if i dont write this if(todo)
    //proprety is underfined
    if (todo) {
        todo.completed = !todo.completed;
    }
}
addTodo("Build API");
addTodo("Publish app");
toggleTodo(1);
console.log(todos);
