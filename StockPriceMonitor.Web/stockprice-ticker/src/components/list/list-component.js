import { Fragment } from "react";
import { TabContainer, Table } from "react-bootstrap";
import ListItem from "./list-item/list-item-component";

export default function List(props) {
    return (
        <Fragment>
            <Table bordered>
                <thead>
                    <tr>
                        <th>Time</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {props.items && props.items.map((item, index) => (
                        <ListItem key={index} timeStamp={item.timeStamp} price={item.price}></ListItem>
                    ))}
                </tbody>
            </Table>
        </Fragment>
    );
}