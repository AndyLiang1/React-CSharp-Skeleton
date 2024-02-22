import * as React from "react";
import Form from "react-bootstrap/Form";
import { Button } from "../components";
import { FormState } from "../types";
import { useEffect, useState } from "react";
import {postTodo, getTodos} from '../APIs'
export interface ITodoItemFormProps {
  state: FormState
  refetch: any
}

export function TodoItemForm(props: ITodoItemFormProps) {
  const [name, setName] = useState<string>("")
  const [complete, setComplete] = useState<string>("")
  
  const handleSubmit = async() => {
    const newTodo = {
      name, 
      isComplete: true
    }
    await postTodo(newTodo)
    await props.refetch()
  };
  

  return (
    <Form>
      <Form.Group className="mb-3" controlId="formTaskName">
        <Form.Label>Name</Form.Label>
        <Form.Control placeholder="Name of task" onChange = {(e: any) => setName(e.target.value)} value = {name}/>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formTaskStatus">
        <Form.Label>Complete</Form.Label>
        <Form.Control placeholder="Is the task complete?" onChange = {(e: any) => setComplete(e.target.value)} value = {complete}/>
      </Form.Group>
      <Button variant="primary" onClick = {handleSubmit}>
        {props.state === FormState.Add ? "Add": "Edit"}
      </Button>
    </Form>
  );
}
