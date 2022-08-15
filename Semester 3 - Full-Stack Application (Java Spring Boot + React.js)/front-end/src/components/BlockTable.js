import React, {useEffect, useState} from "react";

import "bootstrap/dist/css/bootstrap.css";
import "react-bootstrap-table-next/dist/react-bootstrap-table2.min.css";

import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";
import {Button} from "reactstrap";
import {Link} from "react-router-dom";
import axios from "axios";


const BlockTable = ({eventId, categoryId}) => {

    const [category, setCategory] = useState('');
    const [blocks, setBlocks] = useState([]);
    const quantity = sessionStorage.getItem("quantity");

    const getCategory = () => {
        axios.get(`categories/${categoryId}`)
            .then(response => {
                setCategory(response.data.name);
            });
    }

    const getAvailableBlocks = () => {
        axios.get(`blocks?eventId=${eventId}&categoryId=${categoryId}&quantity=${quantity}`)
            .then(response => {
                setBlocks(response.data);
            });
    }

    useEffect(() => {
            getCategory();
            getAvailableBlocks();
        }, []
    )

    const columns = [
        {
            dataField: "blockNumber",
            text: "Block",
            sort: true
        },
        {
            dataField: "availability",
            text: "Free Seats",
            sort: true
        },
        {
            dataField: "select",
            text: "Select",
            formatter: (cell, row) => {

                return <Link to={window.location.pathname + `/block/${row.blockNumber}`}>
                    <Button className="select-block-button"> + </Button>
                </Link>;
            }
        }
    ];

    const defaultSortedBy = [{
        dataField: "blockNumber",
        order: "asc"
    }];


    return (
        <div className="blocks-container">
            <div className="category-availability-container">
                Availability for {category}
            </div>
            <div className="ticket-quantity-container">
                Seats Wanted: {quantity}
            </div>
            <div className="blockTable-container">
                <BootstrapTable
                    bootstrap4
                    keyField="id"
                    data={blocks}
                    columns={columns}
                    defaultSorted={defaultSortedBy}
                    pagination={paginationFactory({sizePerPage: 6, hideSizePerPage: true})}
                    rowStyle={{height: '40px', lineHeight: '40px', fontSize: '20px'}}
                />
            </div>
        </div>
    );

}

export default BlockTable;


