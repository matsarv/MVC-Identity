import React, { Component } from "react";

class EditUserForm extends Component {

  constructor(props) {
    super(props);

    const { editCharacter } = this.props

    const {
      id,
      firstName,
      lastName,
      email,
      phone,
      cityId
    } = editCharacter;

    this.initialState = {
      id: id,
      firstName: firstName,
      lastName: lastName,
      email: email,
      phone: phone,
      cityId: cityId
    };

    this.state = this.initialState;
  }

  handleChange = event => {
    const { name, value } = event.target;

    this.setState({
      [name]: value
    });
  };

  onFormSubmit = event => {
    event.preventDefault();
    if (!this.state.id || !this.state.firstName || !this.state.lastName || !this.state.email || !this.state.phone)
      // message

      return

    this.props.updateCharacter(this.state);
    this.setState(this.initialState);
  };

  render() {

    const { id, firstName, lastName, email, phone, cityId } = this.state;

    return (
      <form onSubmit={this.onFormSubmit}>
        <input type="hidden" name="id" value={id} />
        <label>Firstname</label>
        <input
          type="text"
          name="firstName"
          value={firstName}
          onChange={this.handleChange}
        />
        <label>Lastname</label>
        <input
          type="text"
          name="lastName"
          value={lastName}
          onChange={this.handleChange}
        />
        <label>Email</label>
        <input
          type="text"
          name="email"
          value={email}
          onChange={this.handleChange}
        />
        <label>Phone (optional)</label>
        <input
          type="text"
          name="phone"
          value={phone}
          onChange={this.handleChange}
        />
        <label>City (readonly)</label>
        <input
          readOnly
          type="text"
          name="cityId"
          value={cityId}
          onChange={this.handleChange}
        />
        <button type="submit" className="btn  btn-sm btn-primary m-1">Update</button>
        <button type="cancel" className="btn btn-primary m-1">Cancel</button>
      </form>
    );
  }
}

export default EditUserForm;
