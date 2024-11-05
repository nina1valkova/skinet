// union type
let message: string | number = "Hello";
//can be without ttype
message = "Hello again";

//compiler stop me from doin this
//message = false;


let isComplete: boolean = false;
//error
//isComplete =1;

/*
same as type Todo ={}
interface Todo
{
    id:number
    title: string
    completed: boolean
}
*/
type Todo =
{
    id:number
    //optional
    title?: string
    completed: boolean
}

let todos: Todo[] = [];

//explicity call what funtion will return : Todo i mut return Todo from function
function addTodo(title: string) : Todo
{
    const newTodo: Todo =
    {
        id: todos.length + 1,
        title,
        completed: false
    }

    // if it was JavaScipt is possible to let ne to write todos.push(todo);
    todos.push(newTodo);
    return newTodo;
}

function toggleTodo(id: number): void
{
    const todo = todos.find(todo => todo.id == id);
   

    //TypeScript gives error if i dont write this if(todo)
    //proprety is underfined
    if(todo)
    {
        todo.completed = !todo.completed
    }
}

addTodo("Build API");
addTodo("Publish app");
toggleTodo(1);

console.log(todos);