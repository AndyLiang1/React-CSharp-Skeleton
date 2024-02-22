import * as React from "react";
import { TableEntry } from "../types/Table";
import { ReactElement, useEffect, useState } from "react";
import BootstrapTable from 'react-bootstrap/Table';
// import "./Table.module.css"

export interface ITableProps {
  tableData: TableEntry[];
}

export function Table(props: ITableProps) {
  const [tableHeaders, setTableHeaders] = useState<ReactElement[]>([]);
  const [tableRows, setTableRows] = useState<ReactElement[]>([]);

  useEffect(() => {
    setTableHeaders(extractTableHeaders());
    setTableRows(extractTableRows());
  }, [props.tableData]);

  const extractTableHeaders = () => {
    if (props.tableData?.length) {
      const firstRow = props.tableData[0];
      const result = Object.keys(firstRow).map((key, index) => {
        return <th key = {index}>{key}</th>;
      });
      return result;
    }
    return [];
  };

  const extractTableRows = () => {
    if (props.tableData?.length) {
      const result = props.tableData.map((row, index) => {
        const oneRow = Object.keys(row).map((key, index) => {
          return <td key = {index}>{row[key]}</td>;
        });
        
        return <tr key = {index}>{oneRow}</tr>;
      });
      return result;
    }
    return [];
  };
  return (
    <BootstrapTable striped bordered hover>
      <thead>
        <tr>
          {tableHeaders}
        </tr>
      </thead>
      <tbody>
          {tableRows}
      </tbody>
    </BootstrapTable>
  );
}
