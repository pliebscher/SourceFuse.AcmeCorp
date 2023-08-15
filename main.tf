provider "aws" {
  region = "us-west-2"
}

resource "aws_ecs_cluster" "acmecorp_cluster" {
  name = "acmecorp-ecs-cluster"
}

resource "aws_ecs_task_definition" "acmecorp_task" {
  family                   = "acmecorp-family"
  network_mode             = "bridge"

  container_definitions = jsonencode([
    {
      name  = "frontend-api"
      image = "pliebscher/sourcefuse.acmecorp.webapi:latest"
      cpu       = 1
      memory    = 1024
      portMappings = [
        {
          containerPort = 80,
          hostPort      = 80
        }
      ]
    },
    {
      name  = "backend-db"
      image = "mcr.microsoft.com/mssql/server:2019-latest"
      cpu       = 1
      memory    = 2048
      portMappings = [
        {
          containerPort = 1433,
          hostPort      = 1433
        }
      ]
    }
  ])
}

resource "aws_ecs_service" "acmecorp-ecs-cluster" {
  name            = "acmecorp-ecs-service"
  task_definition = aws_ecs_task_definition.acmecorp_task.arn
  launch_type     = "EC2"

  network_configuration {
    assign_public_ip = true
    subnets = ["subnet-05afdd6a88a86bf7a", "subnet-0d95de4f657af4718"]
  }
}
