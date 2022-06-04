export default function ListItem(props) {
    return (
        <tr>
            <td>{props.timeStamp}</td>
            <td>{props.price}</td>
        </tr>
    );
}