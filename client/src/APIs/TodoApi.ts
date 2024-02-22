import axios, { AxiosError, AxiosResponse } from "axios";
import { TodoItem } from "../types";

export const BASE_URL = "https://localhost:7267";

export async function getTodos() {
  try {
    const response = await axios.get(`${BASE_URL}/api/TodoItems`);
    return response.data;
  } catch (err: any) {
    console.log(err)
  }
}
export async function postTodo(body: TodoItem) {
  try {
    const response = await axios.post(`${BASE_URL}/api/TodoItems`, body);
    return response.data;
  } catch (err: any) {
    console.log(err)
  }
}

