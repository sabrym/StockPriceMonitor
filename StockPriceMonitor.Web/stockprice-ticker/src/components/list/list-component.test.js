import { render, screen } from '@testing-library/react';
import List from './list-component';
import React from 'react';
/**
 * @jest-environment jsdom
 */

it('renders without crashing', () => {
    const div = document.createElement('div');
    render(<List />, div);
});

it('renders message if no items present', () => {
    render(<List />);
    expect(screen.getByTestId("stock-items").innerHTML).toEqual("<tr><td>No valid items</td></tr>");
});

it('renders table items when props passed', () => {
    const listItems = [
        {
            timeStamp: "1999.03.03 19:00:00",
            price: "300.0"
        }
    ];

    const rendered = render(<List items={listItems}/>);
    expect(rendered.getByTestId("stock-items").innerHTML).toEqual(`<tr><td>${listItems[0].timeStamp}</td><td>${listItems[0].price}</td></tr>`);
});

