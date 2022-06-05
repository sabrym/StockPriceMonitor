export default function ListItem(props) {
    if (props) {
        return (

            <tr>
                <td>{props.timeStamp}</td>
                <td>{props.price}</td>
            </tr>
        );
    }
    else {
        <span>No valid items</span>
    }

}