import { useEffect, useState } from 'react';
import * as React from 'react';
import { getTodos } from '../APIs';
import { Button, Table } from '../components';
import { FormState, TodoItem } from '../types';
import { TodoItemForm } from "../Forms/TodoItemForms"
import styles from "./MainPage.module.css"
export interface IMainPageProps {
}

export function MainPage (props: IMainPageProps) {
  const [tableData, setTableData] = useState<TodoItem[]>([]);
  const [displayForm, setDisplayForm] = useState<boolean>(false)
  const [formState, setFormState] = useState<FormState>(FormState.Add)
  
  const initTable = async() => {
    try {
      const response = await getTodos(); 
      setTableData(response)
    } catch (err: any) {
      console.error(err)
    }
  }

  const handleAddEditClicked = (state: FormState) => {
    setFormState(state)
  }

  

  useEffect(() => {
    setDisplayForm(true)
  },[formState])
  
  useEffect(() => {
    initTable()
  }, [])
  return (
    <div>
       <Table 
        tableData = {tableData}/>
        <Button onClick = {() => handleAddEditClicked(FormState.Add)}>Add</Button>
        <Button onClick = {() => handleAddEditClicked(FormState.Edit)}>Edit</Button>
        {displayForm && <TodoItemForm state = {formState} refetch = {initTable}></TodoItemForm>}
        <div className={styles.nav_bar}>
          <div className={styles.first_part}></div>
        </div>
    </div>
  );
}
