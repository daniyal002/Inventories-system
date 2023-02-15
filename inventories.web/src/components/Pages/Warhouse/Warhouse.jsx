import React from "react";
import axios from "axios";
import "./Warhouse.css";
import WarehouseItem from "./WarehouseItem/WarehouseItem";
import Post from "./WarhousePost/Post";
import { Input, Row, Col } from "antd";

const Warhouse = () => {
  const [error, setError] = React.useState(null);
  const [isLoader, setIsLoader] = React.useState(false);
  const [warehouse, setWarehouse] = React.useState([]);
  const [searchValue, setSearchValue] = React.useState("");

  const filtered = warehouse.filter((item) => {
    return item.warehouseName.toLowerCase().includes(searchValue.toLowerCase());
  });

  React.useEffect(() => {
    axios.get("https://localhost:7274/api/warehouses").then(
      (result) => {
        setIsLoader(true);
        setWarehouse(result.data.result);
      },
      (error) => {
        setIsLoader(true);
        setError(error);
      }
    );
  }, [warehouse]);

  if (error) {
    return <div>Error: {error.message}</div>;
  } else if (!isLoader) {
    return <div>Loading...</div>;
  } else {
    return (
      <div className="items">
        <Row justify="center">
          <Col xs={10} sm={10} md={10} lg={10} xl={8}>
            <Post url={"https://localhost:7274/api/warehouses"} />
          </Col>
          <Col xs={10} sm={10} md={10} lg={10} xl={10}>
            <Input
              onChange={(event) => setSearchValue(event.target.value)}
              addonAfter="Поиск"
            />
          </Col>
        </Row>
        <Row justify="center">
          <Col xs={22} sm={22} md={22} lg={18} xl={18}>
            <WarehouseItem warehouse={filtered} />
          </Col>
        </Row>
      </div>
    );
  }
};

export default Warhouse;
