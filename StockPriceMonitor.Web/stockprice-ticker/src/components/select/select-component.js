import Form from 'react-bootstrap/Form';

export default function Selector(props) {
  return (
    <Form.Select onChange={(e) => { props.onchange(e.target.value, props.type) }} value={props.selectedValue}>
      {props.items.map(item => (
        <option key={item.id} value={item.id}>
          {item.name}
        </option>
      ))}
    </Form.Select>
  );
}