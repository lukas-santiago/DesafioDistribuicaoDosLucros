import BTable from 'react-bootstrap/Table';
import { Hooks, TableOptions, useTable } from 'react-table';
import { ColumnDef } from '@tanstack/react-table';
import React from 'react';

export function GenericTable<T extends object>({
  options, plugins,
}: {
  options: TableOptions<T>;
  plugins: ColumnDef<T>[];
}) {
  const tableHooks = (hooks: any): Hooks => hooks.visibleColumns.push((columns: ColumnDef<T>[]) => [
    ...columns,
    ...plugins,
  ]);

  const { getTableProps, headerGroups, rows, prepareRow } = useTable(
    options,
    tableHooks
  );
  return (
    <>
      <BTable className="rounded-5" striped size='sm' hover {...getTableProps()}>
        <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps()}>{column.render('header')}</th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody>
          {rows.map((row, i) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => {
                  return <td {...cell.getCellProps()}>{cell.render('Cell')}</td>;
                })}
              </tr>
            );
          })}
        </tbody>
      </BTable>
    </>
  );
}
